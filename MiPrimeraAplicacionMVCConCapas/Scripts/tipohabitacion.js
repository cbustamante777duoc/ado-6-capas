window.onload = function () {
    listarTipoHabitacion();
}

function listarTipoHabitacion() {
    pintar({
        url: "TipoHabitacion/lista", id: "divTabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades: ["id", "nombre", "descripcion"],
        editar: true,
        eliminar: true,
        propiedadID:"id"

    })

    

}

//en el buscar se usa el pintar pero se cambia la url
function Buscar() {
    var nombreTipoHabitacion = get("txtNombreTipoHabitacion")
    //alert(nombreTipoHabitacion);
    pintar({
        url: "TipoHabitacion/filtrarTipoHabitacionPorNombre/?nombreHabitacion=" + nombreTipoHabitacion,
        id: "divTabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades: ["id", "nombre", "descripcion"],
        editar: true,
        eliminar: true,
        propiedadID: "id"

    })

}

//funcion que limpia los campos del formulario a traves de los name que tiene los input
function Limpiar() {
    //setName("id", "")
    //setName("nombre", "")
    //setName("descripcion","")

    //var elementos = document.querySelectorAll("#frmTipoHabitacion [name]");

    //for (var i = 0; i < elementos.length; i++) {
    //    elementos[i].value = "";
    //}

    LimpiarDatos("frmTipoHabitacion", ["id"]);
    Correcto("Funciono mi alerta");
}

function GuardarDatos() {

    var frmTipoHabitacion = document.getElementById("frmTipoHabitacion");
    var frm = new FormData(frmTipoHabitacion);
    fetchPostText("TipoHabitacion/guardarDatos", frm, function (res) {

        if (res == "1") {

            listarTipoHabitacion();
            Limpiar();

        }
    })


    /*
    fetch("TipoHabitacion/guardarDatos", {
        method: "POST",
        body: frm
    }).then(res => res.text())
        .then(res => {
            if (res == 1) {

                listarTipoHabitacion();

            }
        })*/


}

function Editar(id) {
    /*
    fetchGet("TipoHabitacion/recuperarTipoHabitacion/?id=" + id, function (res) {
        setName("id", res.id)
        setName("nombre", res.nombre)
        setName("descripcion", res.descripcion)

    })*/

    recuperarGenerico("TipoHabitacion/recuperarTipoHabitacion/?id=" + id,"frmTipoHabitacion")

}