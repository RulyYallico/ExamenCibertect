import React from 'react'
import './App.css'
import Principal, { Secundario, MostrarNombres, MostrarNombre } from './components/Ejemplo'

function ProcesoQueTomaMuchoTiempo() {
    setTimeout(function(){
        alert("Termino el proceso")
    }, 3000)
}

const App: React.FC =  () => {
    return (
        <div className="App">
            <Principal></Principal>
            <Secundario></Secundario>
            <MostrarNombres nombres={["nombre1", "nombre2"]} />
            <MostrarNombre nombre="Ruly" numeroDeVeces={20} />
            <hr/>
            
        </div>
    );
}


export default App;