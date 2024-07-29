using System;
using System.Collections.Generic;
using TMM022_fmb.Repositories;
using TMM022_fmb.DTOs;
using TMM022_fmb.Models;

namespace TMM022_fmb.Services
{
    public class FormService
    {
        private readonly FormRepository _formRepository;

        public FormService(FormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public FormInitializationDTO InitializeForm()
        {
            // Retrieve the necessary data for form initialization
            FormModel formModel = _formRepository.GetFormInitializationData();

            // Map the FormModel data to a FormInitializationDTO object
            FormInitializationDTO formInitializationDTO = new FormInitializationDTO
            {
                MainWindowMaximized = true,
                Title = "T K A P - [IS]",
                CurrentDate = DateTime.Now,
                GlobalParameter = 0,
                Mode = formModel.GlobalParameter == 0 ? "Create Mode" : "Edit Mode",
                CursorStyle = "default",
                SaveButtonEnabled = false,
                FieldsEnabled = new Dictionary<string, bool>
                {
                    { "GroupID", true },
                    { "PartNumber", true },
                    { "PartStatus", true },
                    { "PartDescription", true },
                    { "LineID", true },
                    { "UnitID", true }
                },
                FocusField = "Unit ID"
            };

            return formInitializationDTO;
        }
    }
}