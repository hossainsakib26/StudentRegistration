using StudentRegistration.Models.Enums;

namespace StudentRegistration.Services
{
    public class ServeAlert
    {
        public static string ShowAlart(Alert objAlert, string msg)
        {
            var alertDiv = "";

            switch (objAlert)
            {
                    //col - md - 10
                case Alert.Success: alertDiv = $"<div class='alert alert-success fw-normal fs-5 mt-2 mt-md-0 col-12' role='alert'>" + msg + "</ div > ";
                    break;
                case Alert.Info: alertDiv = $"<div class='alert alert-info fw-normal fs-5 mt-2 mt-md-0 col-12' role='alert'>" + msg + "</ div > ";
                    break;
                case Alert.Warning: alertDiv = $"<div class='alert alert-Warning fw-normal fs-5 mt-2 mt-md-0 col-12' role='alert'>" + msg + "</ div > ";
                    break;
                case Alert.Danger: alertDiv = $"<div class='alert alert-Danger fw-normal fs-5 mt-2 mt-md-0 col-12' role='alert'>" + msg + "</ div > ";
                    break;
            }

            return alertDiv;
        }
    }
}