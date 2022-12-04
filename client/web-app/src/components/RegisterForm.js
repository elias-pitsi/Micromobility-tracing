import React, { useState } from "react";

const RegisterForm = () => {
  // eslint-disable-next-line no-undef
  const [isError, setIsError] = useState("");
  const [name, SetName] = useState("");
  const [surname, SetSurname] = useState("");
  const [email, SetEmail] = useState("");
  const [password, Setpassword] = useState("");
  const [confirmPassword, SetConfirmPassword] = useState("");

  const checkValidation = (e) => {
    SetConfirmPassword(e.target.value);
    if (password !== confirmPassword) {
      setIsError("Passwords do not match");
    }
  };

  const handleRegistration = (e) => {
    e.preventDefault();
    console.log(name, email, password, confirmPassword);
  };

  return (
    <div className="flex flex-col justify-center">
      <form
        onSubmit={handleRegistration}
        className="max-w-[400px] w-full mx-auto bg-white p-4"
      >
        <div className="flex flex-col py-2">
          <label>Name</label>
          <input
            type="text"
            placeholder="Full Name"
            className="border p-2"
            value={name}
            onChange={(e) => SetName(e.target.value)}
            required="required"
          />
        </div>
        <div className="flex flex-col py-2">
          <label>Surname</label>
          <input
            type="text"
            placeholder="surname"
            className="border p-2"
            value={surname}
            onChange={(e) => SetSurname(e.target.value)}
            required="required"
          />
        </div>
        <div className="flex flex-col py-2">
          <label>email</label>
          <input
            type="email"
            placeholder="user@exmple.com"
            className="border p-2"
            value={email}
            onChange={(e) => SetEmail(e.target.value)}
            required="required"
          />
        </div>
        <div className="flex flex-col py-2">
          <label>Password</label>
          <input
            type="password"
            placeholder="**********"
            className="border p-2"
            value={password}
            onChange={(e) => Setpassword(e.target.value)}
            required="required"
          />
        </div>
        <div className="flex flex-col py-2">
          <label>Confirm Password</label>
          <input
            type="password"
            placeholder="**********"
            className="border p-2"
            value={confirmPassword}
            onChange={checkValidation}
            required="required"
          />
        </div>
        <button className="border w-full my-5 py-2 bg-indigo-600 hoover:bg-indigo-500 text-white">
          Register
        </button>
      </form>
    </div>
  );
};

export default RegisterForm;
