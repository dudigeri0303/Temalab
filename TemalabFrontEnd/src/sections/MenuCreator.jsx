import { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import CategoryComponent from '../components/CategoryComponent';

export default function MenuCreator(){
    useEffect(() => {
        document.title = "Étlap | DineTab";
        getCategories();
    }, []);

    const [category,setCategory] = useState([]);
    const [newCategCame, setNewCategCame] = useState("");
    
    const id = useParams();
    console.log(id)

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
        const response = await fetch("https://localhost:7114/listCategoriesByRestaurantId?restaurantId=" + id.id, requestOptions);
        const data = await response.json();
        setCategory(data);
        console.log(data);
        } catch (error) {
        console.error(error);
        }
    }

    const postCategory = async() => {
        const myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");
        const requestOptions = {
            method: "POST",
            credentials: 'include',
            xhrFields: { withCredentials: true},
            headers: myHeaders,
            mode: 'cors',
            redirect: "follow"
        };
        try {
            const response = await fetch("https://localhost:7114/AddCategory?restaurantId=" + id.id + "&Name=" + newCategCame, requestOptions);
            const result = await response.text();
            console.log(result)
        } catch (error) {
            console.error(error);
        }

        window.location.reload()
    }

    return(
        <>
            <div className='container'>
                {category.map((categ) => (
                    <div key={categ.id}>
                        <CategoryComponent dataf={categ}/>
                    </div>
                ))}
                {console.log(category)}
                <div>
                    <button type='submit' onClick={postCategory}>Add Category</button>
                    <input type='text' onChange={(e) => setNewCategCame(e.target.value)}/>
                </div>
            </div>
        </>
    )
}