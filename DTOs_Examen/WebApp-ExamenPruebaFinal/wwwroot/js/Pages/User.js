//Clase Js - Controlador de la vista Register.cshtml

//Define el nombre de la clase Js
function CreateUserController() {
    this.ViewName = "CreateUser";
    this.ApiService = "User";

    this.InitView = function () {
        console.log("User view init");

        //Asiganacion del evente create

        $("#CreateUser").click(function () {
            var view = new CreateUserController();
            view.Create();
        });

        $("#UpdatePassword").click(function () {
            var view = new CreateUserController();
            view.ResetPassword();
        });

    }

    this.Create = function () {
        //Crear un DTO de user
        alert("Usuario Registrado")
        var user = {};
        user.Name = $("#txt_Name").val();
        user.LastName1 = $("#txt_LastName1").val();
        user.LastName2 = $("#txt_LastName2").val();
        user.Email = $("#").val();
        user.Password = $("#txt_Password").val();
        user.UserCode = " ";
        user.QuestionSecret = $("#SelectQuestion").val();
        user.QuestionAnswer = $("#txt_questionAnserwer").val();

        var ctrlActions = new ControlActions();
        var serviceToCreate = this.ApiService + "/Create";

        ctrlActions.PostToAPI(serviceToCreate, user, function () {
            console.log("Data enviada al API");
        });

        console.log("Message --> " + JSON.stringify(user));
    }

    this.ResetPassword = function () {
        alert("Actualizando Clave");
        var QuestionAnswer = $("#txt_email").val();
        var Password = $("#txt_password").val();
        var updatePWD = "https://localhost:7042/api/User/ProcessPWS?pwrd=" + encodeURIComponent(Password) + "&QuestionAnswer=" + encodeURIComponent(QuestionAnswer);


        var password2 = $("#txt_password2").val();

        if (Password === password2) {
            $.ajax({
                url: updatePWD,
                type: "PUT",
                //dataType: "json",
                //data: JSON.stringify(user),
                //contentType: "application/json",
                success: function (response) {
                    // Manejar la respuesta exitosa de la API aquí
                    $("#resultado").html("Respuesta: " + JSON.stringify(response));
                },
                error: function (xhr, status, error) {
                    // Manejar errores aquí de manera más informativa
                    console.error("Error en la solicitud: " + error);
                    if (xhr.responseText) {
                        console.error("Respuesta del servidor: " + xhr.responseText);
                    }
                }
            });
        } else {
            console.log("Las contraseñas no coinciden");
        }

    }
}
//Instanciamiento inicial de la clase.
//Siempre se ejecuta al finalizar la carga de la página.
//Document: Hace referencia al contenido del HTML
$(document).ready(function () {
    var view = new CreateUserController();
    view.InitView();
});
