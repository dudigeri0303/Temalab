import "../App.css";
import React, { useEffect, useState } from "react";

// eslint-disable-next-line react/prop-types
export default function AllRestaurants({ children }) {
  useEffect(() => {
    getRestaurants();
  }, []);

  const [restaurants, setRestaurants] = useState([]);

  const getRestaurants = async () => {
    const myHeaders = new Headers();
    const requestOptions = {
      method: "GET",
      headers: myHeaders,
      credentials: "include",
      xhrFields: { withCredentials: true },
      redirect: "follow",
    };

    try {
      const response = await fetch(
        "https://localhost:7114/api/Restaurant/listAllRestaurants",
        requestOptions
      );
      const data = await response.json();
      setRestaurants(data);
    } catch (error) {
      console.error(error);
    }
  };
  return <> {children(restaurants)} </>;
}
