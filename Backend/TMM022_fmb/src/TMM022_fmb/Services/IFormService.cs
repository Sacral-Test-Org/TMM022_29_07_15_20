using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMM022_fmb.DTOs;
using TMM022_fmb.Models;

namespace TMM022_fmb.Services
{
    public interface IFormService
    {
        Task<FormInitializationDTO> InitializeForm();
    }
}