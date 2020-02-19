import React from "react"
import { IPageBaseProps, IProduct } from "../types";
import * as SignalR from "@aspnet/signalr";
import { insertarProduct } from "../services/productService";
import { Title } from "../components/global/Title";

export default function InsertarProducto(props: IPageBaseProps) {
    const [mensaje, setMensaje] = React.useState<string>("");
    const [hubConnection, setHubConnection] = React.useState<SignalR.HubConnection>();

    // React.useEffect(() => {
    //     const newConnection = new SignalR.HubConnectionBuilder().withUrl(`${process.env.REACT_APP_BASE_URL}/producthub`).build();

    //     newConnection.start().catch(error => console.error(error));

    //     setHubConnection(newConnection);
    // }, [])   

    const formSubmit = (e: any) => {
        e.preventDefault();
        const newProduct: Partial<IProduct> = {}

        newProduct.productName = e.target["productName"].value;
        newProduct.unitPrice = e.target["productPrice"].value;

        guardarProducto(newProduct);
    }

    const guardarProducto = async (nuevoProducto: Partial<IProduct>) => {
        const resultadoServicio = await insertarProduct(nuevoProducto);

            if (hubConnection) {
            await hubConnection.send("modificarProducto", nuevoProducto)
        }
        
        setMensaje(resultadoServicio);
    }
    return <div>
        <Title texto="Insertar un Producto"></Title>
        <form className="mt-3" onSubmit={formSubmit}>
            <div className="form-group">
                <label htmlFor="productName">Nombre</label>
                <input className="form-control" type="text" name="productName" id="productName" placeholder="Ingresa el nombre del producto"></input>
                <label htmlFor="productPrice">Precio</label>
                <input className="form-control" type="text" name="productPrice" id="productPrice" placeholder="Ingresa el precio del producto"></input>
            </div>
            <button type="submit" className="btn btn-primary">Guardar</button>
        </form>

        <p className="mt-3">Resultado de insertar: {mensaje}</p>
    </div>
}