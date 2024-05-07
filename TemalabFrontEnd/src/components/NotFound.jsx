import React from 'react';

const Login = () => {
  window.open("/", "_self");
};

function NotFound() {
  return (
    <div className="min-vh-100">
      <h1>404 - Page Not Found</h1>
      <p>The page you are looking for might have been removed or is temporarily unavailable.</p>
      <p>Are you possibly not logged in?</p>
      <button className='avgbtn' type="button" onClick={Login}>Log in</button>
    </div>
  );
}


export default NotFound;