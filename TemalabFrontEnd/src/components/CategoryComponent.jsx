import { useState, useEffect } from 'react';
import FoodComponent from './FoodComponent';

export default function CategoryComponent({dataf}){
    const [clicked, setClicked] = useState(false);
    const [foods,setFoods] = useState([]);
    
    useEffect(() => {
        getfoods()
    },[foods])
    
    
    const [fname, setFName] = useState("");
    const [fprice, setFPrice] = useState("");
    const [fdesc, setFDesc] = useState("");
    const [showDiv, setShowDiv] = useState(false);
    const [showBtn, setShowBtn] = useState(true);
    
    const getfoods = async () =>{
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
            "description": fdesc,
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
        setClicked(!clicked)
    }

    const clicknew = () => {
        setShowDiv(!showDiv)
        setShowBtn(!showBtn)
    }

    const delcateg = async() => {
        const myHeaders = new Headers();

        const requestOptions = {
        method: "DELETE",
        headers: myHeaders,
        credentials: 'include',
        xhrFields: { withCredentials: true},
        redirect: "follow"
        };

        try {
            const response = await fetch("https://localhost:7114/deleteCategoryById?categoryId=" + dataf.id, requestOptions);
            const result = await response.text();
            console.log(result);
        } catch (error) {
            console.error(error);
        }
    
        window.location.reload()
    }
    
    return (
        <>
            <div className='d-flex justify-content-between'>
                <h3>{dataf.categoryName}</h3>
                <button className='btnstyle p-2 mb-2' onClick={delcateg}>Kategória törlése</button>
            </div>
            {foods.map((food) => (
                <div key={food.id}>
                    <FoodComponent data={food}/>
                </div>
            ))}
            {showBtn && 
            <div className='row'>
                <button className='btnstyle p-2 col-12' onClick={clicknew}>Új étel hozzáadása</button>
            </div>
            }
            {showDiv && 
            <div className='row'>
                <div className='col-12 col-md-2 d-flex justify-content-center'>
                    <button type='submit' className='btnstyle p-3' onClick={postfood}>Hozzáad</button>
                </div>
                <div className='col-12 col-md-3 d-flex flex-column'>
                    <label>Név:</label>
                    <input className='formtext' type='text' onChange={(e) => setFName(e.target.value)}/>
                </div>
                <div className='col-12 col-md-2 d-flex flex-column'>
                    <label>Ár:</label>
                    <input className='formtext' type='text' onChange={(e) => setFPrice(e.target.value)}/>
                </div>
                <div className='col-12 col-md-3 d-flex flex-column'>
                    <label>Leírás:</label>
                    <input className='formtext' type='text' onChange={(e) => setFDesc(e.target.value)}/>
                </div>
                <div className='col-12 col-md-2 d-flex justify-content-center mt-3 mt-md-0'>
                    <button className='btnstyle p-3' onClick={clicknew}>Mégse</button>
                </div>
            </div>
            }
        </>
    )
}