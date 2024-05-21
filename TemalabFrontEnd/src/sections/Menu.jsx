import { useEffect } from "react";
import "../App.css";
import Navbar from "../components/Navbar";
import CheckAuth from "../common/CheckAuth";
import { useParams } from 'react-router-dom';
import { useState } from "react";
import { useNavigate } from "react-router-dom";

export default function Menu() {

  //--------------------------------------------------

  const navigate = useNavigate(); 

  const [menuItems, setMenuItems] = useState([]);
  const [category, setCategory] = useState([]);

  useEffect(() => {
    document.title = "Menu | DineTab";
    getCategory();
    CheckAuth("customer",navigate)
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

  const goBack= () => {
    window.open("/restaurant/" + id.id, "_self");
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

  const imgconv = new FileReader()

  return (
    <>
      <Navbar />
      <h1 className="display-1 text-center py-3">Menu</h1>
      {/* Kategóriák megjelenítése */}
      <div className="container">
        {category.map((category, index) => (
          <div key={index}>
            <h2 className="display-5 py-2">{category.categoryName}</h2>
            <ul>
              {/* Az adott kategóriába tartozó ételek listázása */}
              {menuItems[index] && menuItems[index].map((menuItem, itemIndex) => (
                <div key={itemIndex}>
                  <div className="row">
                    <div className="col-4">
                      <p>{menuItem.name}</p>
                      <p>{menuItem.description}</p>
                    </div>
                    <div className="col-4">
                      <p className="menu-price">{menuItem.price} Ft</p>
                    </div>
                    <div className="col-4">
                      <img className="imgsizing" src={"data:image/jpeg;base64," + menuItem.image}/>
                    </div>
                  </div>
                  <hr></hr>
                </div>
              ))}
            </ul>
          </div>
        ))}
      </div>
      <button type="button" className="avgbtn" onClick={goBack}>Vissza</button>
    </>
  );
}