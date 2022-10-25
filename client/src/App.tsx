import React, { useEffect, useState } from 'react';

interface Card {
  id: number;
  cardText: string;
}

function App() {
  const [cards, setCards] = useState<Card[]>([]);  
  
  useEffect(() => {
    fetch('http://localhost:5000/api/cards')
        .then(response => response.json())
        .then(data => setCards(data))
  }, [])
  
  return (
    <div>
      <h1>Glory to Ukraine!</h1>
      <ul>
        {cards.map(card => (
            <li key={card.id}>{card.cardText}</li>
        ))}
      </ul>
    </div>
  );
}

export default App;
