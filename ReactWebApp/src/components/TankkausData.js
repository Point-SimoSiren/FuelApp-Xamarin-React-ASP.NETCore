import React from 'react'
import '../App.css'
import { Button } from 'react-bootstrap'

const TankkausData = ({ tankkaukset }) => tankkaukset.map(t =>


    <tr key={t.tankkausId}>
        <td>{t.pvm}</td>
        <td >{t.reknro}</td>
        <td>{t.mittarilukema}</td>
        <td>{t.euroa}</td>
        <td>{t.litraa}</td>
        <td>{t.ajomaara}</td>
        <td>{t.keskikulutus}</td>
        <Button>poista</Button>
    </tr>
)

export default TankkausData