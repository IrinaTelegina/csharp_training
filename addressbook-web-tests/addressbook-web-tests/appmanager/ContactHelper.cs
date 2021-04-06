﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAdressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        public ContactHelper RemoveContact(int p)
        {
            SelectContact(p);
            RemoveContact();
           // manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper CreateContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper ModifyContact(int p, ContactData newContact)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(p);
            InitContactModification();
            NameAndLastname(newContact);
            SubmitContactModification();
            manager.Navigator.ReturnToHomePage();
            return this;
        }


        public ContactHelper NameAndLastname(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Name);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            return this;
        }

        
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
        public ContactHelper SubmitContact()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public ContactHelper InitContactModification()
        {

            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }
        private ContactHelper SelectContact(int p)
        {
            driver.FindElement(By.Id("5")).Click();
            return this;
        }
    }
}
