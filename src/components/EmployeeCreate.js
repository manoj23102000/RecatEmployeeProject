import axios from 'axios';
import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom';
import './EmployeeCreate.css'
import swal from 'sweetalert';

 function EmployeeCreate() {
    const [Name,setName] = useState("");
    const [Band,setBand] = useState("");
    const [Role,setRole] = useState("");
    const [Designation,setDesignation] = useState("");
    const [Responsibilities,setResponsibilities] = useState("");
    const navigate=useNavigate();

    const handleReset=(e)=>{
      setName("");
      setBand("");      
      setRole("");
      setDesignation("");      
      setResponsibilities("");
    }

    const handleSubmit = (e)=>{
        e.preventDefault();
        const data = {employeeName:Name, band:Band,role:Role,designation:Designation,responsibilities:Responsibilities}
        axios.post("https://localhost:44319/api/Employees", data).then((result)=>{
          swal({
            title: "Good job!",
            text: "Created Succesfully!",
            icon: "success",
            button: "Ok",
          });
            console.log(result.data);
        }).then((res)=>{navigate("/")})
        .catch(error=>console.log(error))
    }

  return (
    <div className="testbox">
    <form method="POST" onSubmit={handleSubmit}>
      <div className="item">
        <label htmlFor="employeeName" className="form-label">
          Name
        </label>
        <input
         required
          type="text"
          className="form-control"
          name="employeeName"
          value={Name}
          onChange={e=>setName(e.target.value)}
        />
        </div>
        <div className="item">
        <label htmlFor="band" className="form-label">
          Band
        </label>
        <input
        required
          type="text"
          className="form-control"
          name="band"
          value={Band}
          onChange={e=>setBand(e.target.value)}
        />
        </div>
        <div className="item">
        <label htmlFor="role" className="form-label">
          Role
        </label>
        <input
          type="text"
          className="form-control"
          name="role"
          value={Role}
          onChange={e=>setRole(e.target.value)}
          required
        />
        </div>
        <div className="item">
        <label htmlFor="designation" className="form-label">
          Designation
        </label>
        <input
        required
          type="text"
          className="form-control"
          name="designation"
          value={Designation}
          onChange={e=>setDesignation(e.target.value)}
        />
        </div>
        <div className="item">
        <label htmlFor="responsibilities" className="form-label">
          Responsibilities
        </label>
        <input
        required
          type="text"
          className="form-control"
          name="responsibilities"
          value={Responsibilities}
          onChange={e=>setResponsibilities(e.target.value)}
        />
        </div>
      <div className="btn-block">
        <button type="submit" className="button1 btn btn-dark">
          {" "}
          Submit{" "}
        </button>
        <button type="submit" onClick={handleReset} className="button1 btn btn-dark">
          {" "}
          Reset{" "}
        </button>
        <button onClick={()=>{navigate("/")}} type="button" className="button1 btn btn-dark" >
          Cancel
        </button>
      </div>
    </form>
    </div>
  )
}
export default EmployeeCreate;