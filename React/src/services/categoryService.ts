import axios from "axios";
import { ICategory } from "../types";

export async function ObtenerTodos() : Promise<ICategory[]>{
    const resultado = await axios.get(`${process.env.REACT_APP_BASE_URL}/Category/ListAll`);

    return resultado.data as ICategory[];
}