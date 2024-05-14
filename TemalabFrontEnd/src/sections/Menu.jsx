import "../App.css";
import Navbar from "../components/MenuNavbar";
import { useEffect } from "react";
import { useParams } from 'react-router-dom';
import { useState } from "react";

export default function Menu() {

  //--------------------------------------------------

  const [menuItems, setMenuItems] = useState([]);
  const [category, setCategory] = useState([]);

  useEffect(() => {
    document.title = "Menu | DineTab";
    getCategory();
    getMenuItems();
  }, []);

  const id = useParams();

  const getCategory = async () => {
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
      console.log(error);
    }
  };


  const getMenuItems = async () => {
    const myHeaders = new Headers();

    const requestOptions = {
      method: "GET",
      headers: myHeaders,
      redirect: "follow",
      credentials: 'include',
      xhrFields: { withCredentials: true},
    };

    try {
      const response = await fetch("https://localhost:7114/api/Food/GetMenuItems?restaurantId=" + id.id, requestOptions);
      const data = await response.json();
      setMenuItems(data);
      console.log(data);
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <>
      <Navbar />
      <h1 className="display-1 text-center py-3">Menu</h1>
      {/* Kategóriák megjelenítése */}
      {category.map((category, index) => (
        <div key={index}>
          <h2 className="display-5 py-2">{category.categoryName}</h2>
          <ul>
            {/* Az adott kategóriába tartozó ételek listázása */}
            {menuItems[index] && menuItems[index].map((menuItem, itemIndex) => (
              <li key={itemIndex}>
                <span>{menuItem.name}</span>
                <span className="menu-price">{menuItem.price} Ft</span>
                <p>{menuItem.description}</p>
                <hr></hr>
              </li>
            ))}
          </ul>
        </div>
      ))}
    </>
  );
}


























/*

  return (
    <>
      <Navbar />
      <h1 className="display-1 text-center py-3">Menu</h1>
      
      {Object.entries(groupedFoods).map(([mealType, foods]) => (
        <div key={mealType}>
          <h2 className="display-5 py-2">{mealType}</h2>
          <ul>
           
            {foods.map((food, index) => (
              <li key={index}>
                <span>{food.foodName}</span>
                <span className="menu-price">{food.price}</span>
               
                {index < foods.length && <hr className="hr-menu" />}
              </li>
            ))}
          </ul>
        </div>
      ))}
    </>
  );
}

*/



/*
   const groupedFoods = foods.reduce((acc, food) => {
       if (!acc[food.category]) {
         acc[food.category] = [];
       }
       acc[food.category].push(food);
       return acc;
     }, {});
 */







/*

    const foods = [];

// Új food objektum hozzáadása a foods listához
function addFood(category, foodName, price) {
  const newFood = {
    category: category,
    foodName: foodName,
    price: price
  };
  foods.push(newFood);
}

//Ez csak példa adat
addFood("Ebéd", "Gulyás", 1500);
addFood("Ebéd", "Spagetti", 1200);
addFood("Ebéd", "Krumplifőzelék", 2300);
addFood("Ebéd", "Pecsenye", 3500);

addFood("Leves", "Tyúkleves", 3500);
addFood("Leves", "Paradicsom", 3500);
addFood("Leves", "Gyümölcs", 3500);
addFood("Leves", "Tejszines", 3500);

*/