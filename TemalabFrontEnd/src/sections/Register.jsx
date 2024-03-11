import { useState } from 'react';
import "../App.css";

const RegisterForm = () => {
  const [userName, setUserName] = useState('');
  const [email, setEmail] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');
  const [password, setPassword] = useState('');
  const [passwordAgain, setPasswordAgain] = useState('');
  const [customer, setCustomer] = useState(false);
  const [owner, setOwner] = useState(false);

  const handleSubmit = (e) => {
    e.preventDefault();
    // Ez fog a submit gomb megynyomásakor lefutni
  };

  return (
    <form onSubmit={handleSubmit}>

      <div className="mb-3">
        <input
          className="form-control"
          type="text"
          placeholder="UserName"
          value={userName}
          onChange={(e) => setUserName(e.target.value)}
          required
        />
      </div>

      <div className="mb-3">
        <input
          className="form-control"
          type="text"
          placeholder="Email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          required
        />
      </div>

      <div className="mb-3">
        <input
          className="form-control"
          type="text"
          placeholder="Phonenumber"
          value={phoneNumber}
          onChange={(e) => setPhoneNumber(e.target.value)}
        />
      </div>

      <div className="mb-3">
        <input
          className="form-control"
          type="password"
          placeholder="Password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          required
        />
      </div>

      <div className="mb-3">
        <input
          className="form-control"
          type="password"
          placeholder="Password again"
          value={passwordAgain}
          onChange={(e) =>  setPasswordAgain(e.target.value)}
          required
        />
      </div>

      <div className="mb-3">
        <label>
          <input
            type="checkbox"
            checked={customer}
            onChange={(e) => {
            setCustomer(e.target.checked);
            setOwner(false); // Ha a "Customer" checkbox ki van választva, a "Owner" checkbox legyen kikapcsolva
            }}
          />
          Customer
        </label>
      </div>

      <div className="mb-3">
        <label>
          <input
            type="checkbox"
            checked={owner}
            onChange={(e) => {
            setOwner(e.target.checked);
            setCustomer(false); // Ha az "Owner" checkbox ki van választva, a "Customer" checkbox legyen kikapcsolva
          }}
          />
          Owner
        </label>
      </div>

      <div className="mb-3">
        <button type="submit">Register</button>
      </div>

    </form>
  );
};

export default RegisterForm;