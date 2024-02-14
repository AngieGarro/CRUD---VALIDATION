function LoginController() {

    this.apiService = "Login";

    //var data;
    let Email = $("#txt_Email").val();
    let Password = $("#txt_Password").val();


    this.InitView = function () {

        $("#LoginUser").click(function () {

            var view = new LoginController();
            view.IniciarSesion();
        });
    }

    this.IniciarSesion = function () {

        if (Email === "" || Password === "") {
            alert("Campos requeridos")

        } else {
            var ctrlActions = new ControlActions();
            var serviceToCreate = this.apiService + `/Login?correo=${Email}&clave=${Password}`;

            ctrlActions.PostToAPILogin(serviceToCreate)
            console.log("Procesando");

        }
    };

}

$(document).ready(function () {
    var view = new LoginController();
    view.InitView();
});