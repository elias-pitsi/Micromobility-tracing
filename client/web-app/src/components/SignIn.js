import React, { useState } from "react";
// import { useNavigate } from "react-router-dom";

import bikeImg from "../assets/bike.png";

const SignIn = () => {
  // let navigate = useNavigate();
  const [email, setEmail] = useState("");
  const [emailError, setEmailError] = useState("");

  const [password, setPassword] = useState("");
  const [passwordError, setPasswordError] = useState("");

  const [successMsg, setSuccessMsg] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();

    if (email !== "") {
      const emailRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
      if ( emailRegex.test( email ) )
      {
        setEmailError( "" );
      }
      else
      { 
        setEmailError( "Invalid email address" );
      }
    }
    else
    {
      setEmailError("Email Required");
    }

    if (password !== "") {
    } else {
      setPasswordError("Password Required");
    }
    const data = {
      email: email,
      password: password,
    };

    console.log(data);
  };

  const handleEmailChange = (e) => {
    setSuccessMsg("");
    setPasswordError("");
    setEmail(e.target.value);
  };

  const handlePasswordChange = (e) => {
    setSuccessMsg("");
    setEmailError("");
    setPassword(e.target.value);
  };

  return (
    <div className="grid grid-cols-1 sm:grid-cols-2  h-screen w-full ">
      <div className="hidden sm:block">
        <img className="w-full h-full object-contain" src={bikeImg} alt="" />
      </div>

      <div className="flex flex-col justify-center">
        <form
          onSubmit={handleSubmit}
          className="max-w-[400px] w-full mx-auto bg-white p-4"
        >
          <h2 className="text-4xl font-bold text-center py-6">Micromobility</h2>
          <div className="flex flex-col py-2">
            <label>Username</label>
            <input
              type="email"
              placeholder="user@exmple.com"
              className="border p-2"
              value={email}
              onChange={handleEmailChange}
              required="required"
            />
          </div>
          {emailError && <div className="text-red-600">{emailError}</div>}
          <div className="flex flex-col py-2">
            <label>Password</label>
            <input
              type="password"
              placeholder="**********"
              className="border p-2"
              value={password}
              onChange={handlePasswordChange}
              required="required"
            />
            {passwordError && (
              <div className="text-red-600">{passwordError}</div>
            )}
          </div>
          <button
            className="border w-full my-5 py-2 bg-indigo-600 hoover:bg-indigo-500 text-white"
            // onClick={navigate("/home")}
          >
            Sign In
          </button>
          <div className="flex justify-between">
            <p className="flex items-center">
              <input type="checkbox" className=" mr-2" />
              Remember me
            </p>
            <p>
              <a href="register">Create an account</a>
            </p>
          </div>
        </form>
      </div>
    </div>
  );
};

export default SignIn;
