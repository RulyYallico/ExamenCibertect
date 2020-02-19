import React from 'react';
import './App.css';
import {Link, Router} from '@reach/router';
import { ListaCategorias } from './pages/ListaCategorias';
import { ListaProductos } from './pages/ListaProduct';
import InsertarProducto from './pages/InsertarProducto';

export default function App(){
  return <>
    <nav className="navbar navbar-dark fixed-top bg-dark flex-md-nowrap p-0 shadow">
        <a className="navbar-brand col-sm-3 col-md-2 mr-0" href="#">Vivero Esperanza</a>
        <input className="form-control form-control-dark w-100" type="text" placeholder="Buscar..." />
        <ul className="navbar-nav px-3">
            <li className="nav-item text-nowrap">
                <a className="nav-link" href="#">Cerrar Sesión</a>
            </li>
        </ul>
    </nav>

    <div className="container-fluid">
      <div className="row">
          <nav className="col-md-2 d-none d-md-block bg-light sidebar">
              <div className="sidebar-sticky">
                  <ul className="nav flex-column">
                      <li className="nav-item">
                          <Link className="nav-link" to="/products">Productos</Link>
                      </li>
                      <li className="nav-item">
                          <Link className="nav-link" to="/categories">Categorías</Link>
                      </li>
                  </ul>
              </div>
          </nav>
          <main role="main" className="col-md-9 ml-sm-auto col-lg-10 px-4">
              {/* Estas son las rutas disponibles para redireccionar */}
              <Router>
                  
                    <ListaProductos path="/products"></ListaProductos>
                    <ListaCategorias path="/categories"></ListaCategorias>
                    <InsertarProducto path="/products/insert"></InsertarProducto>
                  {/* <DetalleProducto path="/products/:productId"></DetalleProducto>
                  <InsertarProducto path="/products/insert"></InsertarProducto>  */}
              </Router>
          </main>
      </div>
    </div>
  </>
}
