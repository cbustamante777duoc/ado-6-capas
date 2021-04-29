window.onload = function () {

    listarProductos();
}

function listarProductos() {

    pintar({
        url: "Producto/lista", id: "divTabla",
        cabeceras: ["Id Producto", "Nombre producto","Nombre marca", "Precio","stock","Denominacion"],
        propiedades: ["iidproducto", "nombreProducto","nombreMarca","precioVenta", "stock","denominacion"]
    })

}

function Buscar() {


}