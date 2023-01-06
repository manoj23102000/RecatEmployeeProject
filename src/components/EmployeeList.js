import { Link, useNavigate } from "react-router-dom";
import axios from "axios";
import React, { useState, useEffect } from "react";
import "./EmployeeList.css";
import Timer from "./Timer";

function EmployeeList() {
  const navigate = useNavigate();
  const [getEmployee, setgetEmployee] = useState([]);
  const [searchTerm, setSearchTerm] = useState("");
  const [message, setMessage] = useState("");

  const handleUpdate = (id) => {
    navigate("/updateEmployee/" + id);
  };

  const handleDelete = (id) => {
    navigate("/deleteEmployee/" + id);
  };

  const handleClick = () => {
    setSearchTerm(message);
  };

  const handleChange = (event) => {
    setMessage(event.target.value);
  };

  useEffect(() => {
    axios
      .get("https://localhost:44319/api/Employees")
      .then((response) => {
        setgetEmployee(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);
  return (
    <div>
      <div className="timer">
        <Timer></Timer>
      </div>
      <div className="container">
        <h2 className="banner1">React Web Api</h2>
        <input
          className="search"
          id="message"
          name="message"
          onChange={handleChange}
          value={message}
          type="text"
          placeholder="Search..."
        />
        <button className="btnSearch" onClick={handleClick}>
          Search
        </button>
        <table className="table">
          <thead>
            <tr>
              <th scope="col">EmployeeId</th>
              <th scope="col">EmployeeName</th>
              <th scope="col">Band</th>
              <th scope="col">Role</th>
              <th scope="col">Designation</th>
              <th scope="col">Responsibilities</th>
              <th scope="col">Operations</th>
            </tr>
          </thead>
          <tbody>
            {getEmployee
              .filter((record) => {
                if (searchTerm == "") {
                  return record;
                } else if (
                  record.designation
                    .toLowerCase()
                    .includes(searchTerm.toLowerCase())
                ) {
                  return record;
                }
              })
              .map((record, index) => {
                return (
                  <tr key={index}>
                    <td>{record.employeeId}</td>
                    <td>{record.employeeName}</td>
                    <td>{record.band}</td>
                    <td>{record.role}</td>
                    <td>{record.designation}</td>
                    <td>{record.responsibilities}</td>
                    <td>
                      <a
                        className="button btn btn-dark"
                        onClick={() => {
                          handleUpdate(record.employeeId);
                        }}
                      >
                        Update
                      </a>
                      <a
                        className="button btn btn-dark"
                        onClick={() => {
                          handleDelete(record.employeeId);
                        }}
                      >
                        Delete
                      </a>
                    </td>
                  </tr>
                );
              })}
          </tbody>
        </table>
        <Link to="/createEmployee" className="createButton btn btn-dark">
          CreateNewEmployee
        </Link>
      </div>
    </div>
  );
}

export default EmployeeList;
