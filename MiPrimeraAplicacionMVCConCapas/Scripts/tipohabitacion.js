window.onload = function () {
    listarTipoHabitacion();
}

function listarTipoHabitacion() {
    pintar({
        url: "TipoHabitacion/lista", id: "divTabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades:["id","nombre","descripcion"]})

    

}

//en el buscar se usa el pintar pero se cambia la url
function Buscar() {
    var nombreTipoHabitacion = get("txtNombreTipoHabitacion")
    //alert(nombreTipoHabitacion);
    pintar({
        url: "TipoHabitacion/filtrarTipoHabitacionPorNombre/?nombreHabitacion=" + nombreTipoHabitacion,
        id: "divTabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades: ["id", "nombre", "descripcion"]
    })

}

function GuardarDatos() {

    var frmTipoHabitacion = document.getElementById("frmTipoHabitacion");
    var frm = new FormData(frmTipoHabitacion);
    fetchPostText("TipoHabitacion/guardarDatos", frm, function (res) {

        if (res == "1") {

            listarTipoHabitacion();

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