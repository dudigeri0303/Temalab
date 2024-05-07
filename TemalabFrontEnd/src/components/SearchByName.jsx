import "@fortawesome/fontawesome-free/css/all.min.css";
import React, { useEffect, useState } from "react";
import CardCustomerMain from "../components/CardCustomerMain";

//dependency injection restaurantsList
// eslint-disable-next-line react/prop-types
export default function SearchByName({ restaurantList }) {
  
  const [restaurants, setRestaurants] = useState([]);
  //találatok lista
  const [matches, setMatches] = useState([]);
  //hogy ne írja ki, hogy nincs találat alapból
  const [searchClicked, setSearchClicked] = useState(false);

  useEffect(() => {
    setRestaurants(restaurantList);
  }, [restaurantList]);
  


  const search = () => {
    setSearchClicked(true);
    const foundMatches = [];
    const searchedName = document
      .getElementById("searchedName")
      .value.toLowerCase();
    for (let i = 0; i < restaurants.length; i++) {
      if (restaurants[i].name.toLowerCase().includes(searchedName)) {
        foundMatches.push(restaurants[i]);
      }
    }
    setMatches(foundMatches);
  };

  const cancelSearch = () => {
    location.reload();
  };

  return (
    <>
      <div className="row justify-content-center my-2">
        <div className="col-md-4">
          <div className="input-group rounded">
            <input
              type="search"
              id="searchedName"
              className="form-control rounded"
              placeholder="Keresés"
              aria-label="Search"
              aria-describedby="search-addon"
            />
            <button
              className="input-group-text border-0"
              id="search-addon"
              onClick={search}
            >
              <i className="fas fa-search"></i>
            </button>
          </div>
        </div>
      </div>

      <section id="main" className="container py-2">
        <div className="d-flex justify-content-center">
          {searchClicked && <h1>Találatok:</h1>}
        </div>
        <div className="container py-2">
          <div className="row">
            {matches.map((match) => (
              <div className="col-12 mb-3" key={match.id}>
                <CardCustomerMain data={match} />
              </div>
            ))}
          </div>
        </div>
      </section>
      <div className="d-flex justify-content-center p-4">
        {searchClicked && (
          <button className="avgbtn" onClick={cancelSearch}>
            Keresés törlése
          </button>
        )}
      </div>
      <div>
        {searchClicked && (
          <h1 className="d-flex justify-content-center p-4">
            {" "}
            További éttermek:{" "}
          </h1>
        )}
      </div>
    </>
  );
}
