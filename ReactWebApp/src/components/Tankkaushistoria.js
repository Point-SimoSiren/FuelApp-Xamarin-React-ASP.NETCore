import React, { useState, useEffect } from 'react'
import { Table } from 'react-bootstrap'
import TankkausData from './TankkausData'
import tankkausService from '../services/Tankkaukset'
import '../App.css'

const Tankkaushistoria = ({ lataa }) => {
  const [tankkaukset, setTankkaukset] = useState([{}])

  useEffect(() => {
    tankkausService
      .getAll()
      .then(res => {
        console.log(res)
        setTankkaukset(res)
      })
  }, [lataa])

  if (tankkaukset) {
    return (
      <div className='App'>

        <style type="text/css">
          {`
    .tbl-oma {
      color: white;
      text
      padding: 2rem 2rem;
      font-size: 2rem;
    }
    `}
        </style>

        <Table striped bordered className='tbl-oma'>
          <thead>
            <tr>
              <th>Pvm</th>
              <th>RekNo</th>
              <th>Mittarilukema</th>
              <th>Euroa</th>
              <th>Litraa</th>
              <th>Ajomäärä</th>
              <th>Keskikulutus / 100 km</th>
            </tr>
          </thead>

          <tbody>
            <TankkausData tankkaukset={tankkaukset} />
          </tbody >
        </Table>
      </div>)
  }
  else {
    return <h4>Ladataan..</h4>
  }
}

export default Tankkaushistoria