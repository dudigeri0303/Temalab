import { useState, useEffect } from 'react';
import FoodComponent from './FoodComponent';

export default function CategoryComponent({dataf}){
    
    useEffect(() => {
        getCategories()
    },[])
    
    const [foods,setFoods] = useState([]);
    const [fname, setFName] = useState("");
    const [fprice, setFPrice] = useState("");
    
    const getCategories = async () =>{
        const myHeaders = new Headers();

        const requestOptions = {
        method: "GET",
        headers: myHeaders,
        redirect: "follow",
        credentials: 'include',
        xhrFields: { withCredentials: true},
        };

        try {
        const response = await fetch("https://localhost:7114/api/Food/getMenuItemsByCategoryId?categoryId=" + dataf.id, requestOptions);
        const data = await response.json();
        setFoods(data);
        console.log(data);
        } catch (error) {
        console.error(error);
        }
    }

    const postfood = async() => {
        const myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");
        const raw = JSON.stringify({
            "name": fname,
            "description": "",
            "price": fprice
        });
        const requestOptions = {
            method: "POST",
            credentials: 'include',
            xhrFields: { withCredentials: true},
            headers: myHeaders,
            mode: 'cors',
            body: raw,
            redirect: "follow"
        };
        try {
            await fetch("https://localhost:7114/api/Food/addNewFoodToCategory?categoryId=" + dataf.id, requestOptions);
        } catch (error) {
            console.error(error);
        }

        window.location.reload()
    }
    
    return (
        <>
            <h3>{dataf.categoryName}</h3>
            {foods.map((food) => (
                <div key={food.id}>
                    <FoodComponent data={food}/>
                </div>
            ))}
            {console.log(foods)}
            {console.log(dataf.id)}
            <div>
                <button type='submit' onClick={postfood}>Add Food</button>
                <label>Név:</label>
                <input type='text' onChange={(e) => setFName(e.target.value)}/>
                <label>Ár:</label>
                <input type='text' onChange={(e) => setFPrice(e.target.value)}/>
            </div>
        </>
    )
}