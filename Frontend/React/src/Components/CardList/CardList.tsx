import React from 'react'

import Card from '../Card/Card'

interface Props {}

const CardList = (props: Props) => {
  return (
    <div>
        <Card companyName="Apple" ticker="APPL" price={100}></Card>
        <Card companyName="Microsoft" ticker="MSFT" price={200}></Card>
        <Card companyName="Tesla" ticker="TSLA" price={300}></Card>
    </div>
  )
}

export default CardList