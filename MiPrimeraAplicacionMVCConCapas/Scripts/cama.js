window.onload = function () {
    listarCama();
}

function listarCama() {
    pintar({
        url: "Cama/listarCama",
        id:"divTabla",
        cabeceras: ["Id cama","nombre","descripcion"],
        propiedades: ["idCama", "nombre","descripcion"]

    })
}
