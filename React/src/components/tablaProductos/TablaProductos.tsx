import React from "react";
import { IProduct } from "../../types";
import { TablaProductosHeader } from "./TableProductosHeader";
import { TablaProductosFile } from "./TablaProductosFile";

interface IProps {
    data: IProduct[] // un arreglo de IProduct
    onDeleteProducts: (productId: number) => Promise<void>;
}

export function TablaProductos(props: IProps) {
    return <table className="table table-bordered">
        <TablaProductosHeader></TablaProductosHeader>
        <tbody>
            {props.data.map((productoIterador) => {
                return <TablaProductosFile
                    producto={productoIterador} onDeleteProduct={props.onDeleteProducts}></TablaProductosFile>
            })}
        </tbody>
    </table>
}