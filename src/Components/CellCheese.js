import React from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCheese } from '@fortawesome/free-solid-svg-icons'

export const CellCheese = ({row,col}) => {
    return (
        <div className="square" id={`${row}-${col}`}>
             <FontAwesomeIcon icon={faCheese} size="2x"/>
        </div>
    )
}