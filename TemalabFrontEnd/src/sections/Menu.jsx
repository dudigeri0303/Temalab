import "../App.css";
import Navbar from "../components/MenuNavbar";

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

export default function Menu() {
    const groupedFoods = foods.reduce((acc, food) => {
        if (!acc[food.category]) {
          acc[food.category] = [];
        }
        acc[food.category].push(food);
        return acc;
      }, {});
    
      return (
        <>
          <Navbar />
          <h1 className="display-1 text-center py-3">Menu</h1>
          {/* Csoportok megjelenítése */}
          {Object.entries(groupedFoods).map(([mealType, foods]) => (
            <div key={mealType}>
              <h2 className="display-5 py-2">{mealType}</h2>
              <ul>
                {/* Egy csoportban található ételek megjelenítése */}
                {foods.map((food, index) => (
                  <li key={index}>
                    <span>{food.foodName}</span>
                    <span className="menu-price">{food.price}</span>
                    {/* Vonal hozzáadása az ételek alá */}
                    {index < foods.length  && <hr className="hr-menu"/>}
                  </li>
                ))}
              </ul>
            </div>
          ))}
        </>
      );
    }