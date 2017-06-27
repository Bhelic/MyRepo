using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyRepo.Models;

namespace MyRepo.Controllers
{
    public class BaseController : Controller
    {
        public void Success(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Success, AlertTittles.Success, message, Glyphicons.Success, dismissable);
        }

        public void Information(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Information, AlertTittles.Information, message, Glyphicons.Information, dismissable);
        }

        public void Warning(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Warning, AlertTittles.Warning, message, Glyphicons.Warning, dismissable);
        }

        public void Danger(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Danger, AlertTittles.Danger, message, Glyphicons.Danger, dismissable);
        }
        
        private void AddAlert(string alertStyle, string tittle, string message, string glyphicon, bool dismissable)
        {
            var alerts = TempData.ContainsKey(Alert.TempDataKey)
                ? (List<Alert>)TempData[Alert.TempDataKey]
                : new List<Alert>();

            alerts.Add(new Alert
            {
                AlertStyle = alertStyle,
                Tittle = tittle,
                Message = message,
                Glyphicon = glyphicon,
                Dismissable = dismissable
            });
            TempData[Alert.TempDataKey] = alerts;
        }
    }
}