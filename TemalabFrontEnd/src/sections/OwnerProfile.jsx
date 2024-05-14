import OwnerNavbar from "../components/OwnerNavbar";
import CommonProfile from "../components/CommonProfile";
import { useEffect } from "react";
import CheckAuth from "../common/CheckAuth";
import { useNavigate } from "react-router-dom";

export default function Profile() {

  const navigate = useNavigate(); 

  useEffect(() => {
    CheckAuth("owner",navigate)
  },[])

  return (
    <>
      <OwnerNavbar></OwnerNavbar>
      <CommonProfile></CommonProfile>
    </>
  );
}
