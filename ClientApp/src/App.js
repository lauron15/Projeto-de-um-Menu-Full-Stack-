import { useState } from 'react'
import './App.css'
import { useFoodData } from './components/hooks/useFoodData';
import { CreateModal } from './components/create-modal/create-modal';
import { Card } from './components/Card/card';

function App() {
    const { data } = useFoodData();
    const [isModalOpen, setIsModalOpen] = useState(false);

    const handleOpenModal = () => {
        setIsModalOpen(prev => !prev)
    }

    return (
        <div className="container">
            <h1 style={{ color: 'black' }}>Cardápio</h1>
            <div className="card-grid">
                {data?.map(foodData =>
                    <Card
                        price={foodData.price}
                        title={foodData.name}
                        image={foodData.image}
                    />
                )}
            </div>
            {isModalOpen && <CreateModal closeModal={handleOpenModal} />}
            <button onClick={handleOpenModal}>novo</button>
        </div>
    )
}

export default App