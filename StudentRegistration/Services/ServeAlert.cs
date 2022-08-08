using StudentRegistration.Models.Enums;

namespace StudentRegistration.Services
{
    public class ServeAlert
    {
        public static string ShowAlart(Alert objAlert, string msg)
        {
            var alertDiv = "";
            var crossButton = $"<button type='button' class='btn - close' data-bs-dismiss='alert' aria-label='Close'></button>";

            switch (objAlert)
            {
                //col - md - 10
                case Alert.Success:
                    alertDiv = $"<div class='alert alert-success alert-dismissible fade show fw-normal fs-5 mt-2 mt-md-0 col-12' role='alert'>" + msg + " " + crossButton + "</ div >";
                    break;
                case Alert.Info:
                    alertDiv = $"<div class='alert alert-info alert-dismissible fade show fw-normal fs-5 mt-2 mt-md-0 col-12' role='alert'>" + msg + " " + crossButton + "</ div > ";
                    break;
                case Alert.Warning:
                    alertDiv = $"<div class='alert alert-Warning alert-dismissible fade show fw-normal fs-5 mt-2 mt-md-0 col-12' role='alert'>" + msg + " " + crossButton + "</ div > ";
                    break;
                case Alert.Danger:
                    alertDiv = $"<div class='alert alert-Danger alert-dismissible fade show fw-normal fs-5 mt-2 mt-md-0 col-12' role='alert'>" + msg + " " + crossButton + "</ div > ";
                    break;
            }

            return alertDiv;
        }
    }
}