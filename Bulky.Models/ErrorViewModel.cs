using System.Data;
using BulkyWeb.Models;

namespace BulkyWeb.Models

{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}