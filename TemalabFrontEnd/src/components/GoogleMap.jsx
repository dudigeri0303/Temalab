import React, { useState, useEffect } from 'react';
import { GoogleMap, LoadScript, Marker } from '@react-google-maps/api';
import { geocodeByAddress, getLatLng } from '@react-google-maps/api';

const MapContainer = () => {
  const [center, setCenter] = useState({ lat: 0, lng: 0 });
  const [address, setAddress] = useState("Budapest");

  useEffect(() => {
    const fetchData = async () => {
      try {
        const results = await geocodeByAddress(address);
        const latLng = await getLatLng(results[0]);
        setCenter(latLng);
        console.log(address)
      } catch (error) {
        console.error('Error fetching and parsing data', error);
      }
    };

    fetchData();
  }, [address]);

  const mapStyles = {
    height: "400px",
    width: "100%"
  };

  return (
    <div>
      <LoadScript
        googleMapsApiKey="AIzaSyAkCFbU5vtVRjOpRh77Z4TBEn-zY8i2X_4"
      >
        <GoogleMap
          mapContainerStyle={mapStyles}
          zoom={13}
          center={center}
        >
          <Marker position={center} />
        </GoogleMap>
      </LoadScript>
    </div>
  )
}

export default MapContainer;