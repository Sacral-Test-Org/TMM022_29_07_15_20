using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using TMM022_fmb.Models;

namespace TMM022_fmb.Repositories
{
    public class FormRepository
    {
        private readonly string _connectionString;

        public FormRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public FormModel GetFormInitializationData()
        {
            FormModel formModel = new FormModel();

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (OracleCommand command = connection.CreateCommand())
                {
                    // Set the global parameter
                    formModel.GlobalParameter = 0;

                    // Determine the mode based on the global parameter
                    command.CommandText = "SELECT DECODE(:GLOBAL_PARA, 0, 'Create Mode', 1, 'Edit Mode') FROM DUAL";
                    command.Parameters.Add(new OracleParameter("GLOBAL_PARA", formModel.GlobalParameter));

                    formModel.Mode = command.ExecuteScalar().ToString();

                    // Set other properties
                    formModel.MainWindowMaximized = true;
                    formModel.Title = "T K A P - [IS]";
                    formModel.CurrentDate = DateTime.Now;
                    formModel.CursorStyle = "default";
                    formModel.SaveButtonEnabled = false;

                    // Enable specific fields
                    formModel.FieldsEnabled = new Dictionary<string, bool>
                    {
                        { "GroupID", true },
                        { "PartNumber", true },
                        { "PartStatus", true },
                        { "PartDescription", true },
                        { "LineID", true },
                        { "UnitID", true }
                    };

                    // Set focus field
                    formModel.FocusField = "UnitID";
                }
            }

            return formModel;
        }
    }
}