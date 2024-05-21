import { useState, useEffect } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import CategoryComponent from '../components/CategoryComponent';
import CheckAuth from '../common/CheckAuth';

export default function MenuCreator(){

    const navigate = useNavigate(); 
    const [clicked,setClicked] = useState(false);

    useEffect(() => {
        document.title = "Étlap | DineTab";
        CheckAuth("owner",navigate)
    }, []);

    useEffect(() => {
        getCategories();
    },[clicked])

    const [category,setCategory] = useState([]);
    const [newCategCame, setNewCategCame] = useState("");
    
    const id = useParams();

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
            await fetch("https://localhost:7114/AddCategory?restaurantId=" + id.id + "&Name=" + newCategCame, requestOptions);
        } catch (error) {
            console.error(error);
        }
        setClicked(!clicked);
    }

    const navback = () => {
        navigate('/restaurantowner/' + id.id)
    }

    return(
        <>
            <div className='container'>
                <button onClick={navback} className='btnstyle w-25 p-2 mt-3'>Vissza</button>
                {category.map((categ) => (
                    <div key={categ.id} className='mt-5'>
                        <hr/>
                        <CategoryComponent dataf={categ}/>
                    </div>
                ))}
                <div className='mt-5 row'>
                    <div className='col-12 col-md-4 d-flex align-items-center justify-content-center'>
                        <button type='submit' className='btnstyle p-2' onClick={postCategory}>Kategória hozzáadása</button>
                    </div>
                    <div className='col-12 col-md-8 d-flex align-items-center justify-content-center mt-3 mt-md-0'>
                        <input className='formtext w-75' type='text' onChange={(e) => setNewCategCame(e.target.value)}/>
                    </div>
                </div>
            </div>
        </>
    )
}