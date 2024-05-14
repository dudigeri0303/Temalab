import { useNavigate } from "react-router-dom";
import CryptoJS from 'crypto-js';

export default function CheckAuth(rolename,navigate){
    if(CryptoJS.AES.decrypt(localStorage.getItem('loggedIn'),'kulcs').toString(CryptoJS.enc.Utf8) !== rolename){
        navigate(`*`)
    }
}