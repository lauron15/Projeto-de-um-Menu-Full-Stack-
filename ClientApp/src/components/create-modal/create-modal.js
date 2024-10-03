import { useEffect, useState } from 'react';

import "./modal.css";
import { useFoodDataMutate } from '../hooks/useFoodDataMutate';

interface InputProps {
    label: string,
    value: string | number,
    updateValue(value: any): void
}

interface ModalProps {
    closeModal(): void
}

const Input = ({ label, value, updateValue }: InputProps) => {
    return (
        <>
            <label>{label}</label>
            <input value={value} onChange={event => updateValue(event.target.value)}></input>
        </>
    )
}

export function CreateModal({ closeModal }: ModalProps) {
    const [name, setName] = useState("");
    const [price, setPrice] = useState(0);
    const [image, setImage] = useState("");
    const { mutate, isSuccess, isLoading } = useFoodDataMutate();

    const submit = () => {
        const foodData: FoodData = {
            name,
            price,
            image
        }
        mutate(foodData)
    }

    useEffect(() => {
        if (!isSuccess) return
        closeModal();
    }, [isSuccess])

    return (
        <div className="modal-overlay">
            <div className="modal-body">
                <h2 style={{color: 'black'}}>Cadastre um novo item no cardápio</h2>
                <form className="input-container">
                    <Input label="Nome" value={name} updateValue={setName} />
                    <Input label="Preço" value={price} updateValue={setPrice} />
                    <Input label="Image" value={image} updateValue={setImage} />
                </form>
            
                <button onClick={submit} className="btn-secondary">
                    {isLoading ? 'postando...' : 'postar'}
                </button>
                <button onClick={() => closeModal()} className="btn-outline-primary">
                    Fechar
                </button>
                
            </div>
        </div>
    )
}