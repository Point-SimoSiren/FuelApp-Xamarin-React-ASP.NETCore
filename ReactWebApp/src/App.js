import React, { useState } from 'react'
import Tankkaushistoria from './components/Tankkaushistoria'
import './App.css'
import Button from 'react-bootstrap/Button';
import ButtonGroup from 'react-bootstrap/ButtonGroup';
import 'bootstrap/dist/css/bootstrap.min.css';

const App = () => {

  const [lataa, setLataa] = useState(1)

  return (
    <div className='App'>
      <div className='App-header'>
        <style type="text/css">
          {`
    .btn-oma {
      color: yellow;
      padding: 1rem 1.5rem;
      font-size: 1.5rem;

    }
    `}
        </style>
        <ButtonGroup size="XXL" className="mb-1">

          <Button variant="oma" size="oma" onClick={() => setLataa(lataa + 1)}>
            SNV-748
  </Button>{' '}
          <Button variant="oma" size="oma" onClick={() => alert("Ei tietoja")}>
            ZGB-872
  </Button>
          <Button variant="oma" size="oma" onClick={() => alert("Ei tietoja")}>
            IHX-147
  </Button>
        </ButtonGroup>
        <h1> Fuel Manager</h1>

        <Tankkaushistoria lataa={lataa} />
      </div>
    </div >
  )
}

export default App
