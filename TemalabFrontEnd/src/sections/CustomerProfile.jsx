import Navbar from "../components/Navbar";
import CommonProfile from "../components/CommonProfile";
import { useEffect } from "react";
import CheckAuth from "../common/CheckAuth";
import { useNavigate } from "react-router-dom";

export default function Profile() {

  const navigate = useNavigate(); 

  useEffect(() => {
    CheckAuth("customer",navigate)
  },[])

  return (
    <>
      <Navbar></Navbar>
      <CommonProfile></CommonProfile>
    </>
  );
}
