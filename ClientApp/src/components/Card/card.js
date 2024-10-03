
import "./card.css";

interface CardProps {
    price: number,
    name: string,
    image: string
}

export function Card({ price, image, title }: CardProps) {
    return (
        <div className="card">
            <img src={image} />
            <h2 style={{ color: 'black' }}>{title}</h2>
            <p style={{ color: 'black' }}><b>Valor:</b>{price}</p>
        </div>
    )
}
