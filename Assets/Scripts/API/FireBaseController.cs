﻿using System;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using Firebase.Extensions;

namespace DefaultNamespace.API
{
    public class FireBaseController : MonoBehaviour
    {
        public GameObject loginPanel, signupPanel, profilePanel, forgetPasswordPanel, errorMessagePanel, chosepanel;

        public InputField loginEmail, loginPassword, signupEmail, signupPassword, signupCPassword, signupUsername, forgetPasswordEmail;

        public Text messageTitle, message, username, useremail;

        public Toggle rememberMe;
        
        Firebase.Auth.FirebaseAuth auth;
        Firebase.Auth.FirebaseUser user;

        private bool isSignin = false;
        private void Start()
        {
            Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
                var dependencyStatus = task.Result;
                if (dependencyStatus == Firebase.DependencyStatus.Available) {
                    // Create and hold a reference to your FirebaseApp,
                    // where app is a Firebase.FirebaseApp property of your application class.
                    Debug.Log("giris");
                    InitializeFirebase();

                    // Set a flag here to indicate whether Firebase is ready to use by your app.
                } else {
                    UnityEngine.Debug.LogError(System.String.Format(
                        "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                    // Firebase Unity SDK is not safe to use here.
                }
            });
        }

        public void chosePanel()
        {
            loginPanel.SetActive(false);
            signupPanel.SetActive(false);
            profilePanel.SetActive(false);
            forgetPasswordPanel.SetActive(false);
            chosepanel.SetActive(true);
        }
        public void openLoginPanel()
        {
            loginPanel.SetActive(true);
            signupPanel.SetActive(false);
            profilePanel.SetActive(false);
            forgetPasswordPanel.SetActive(false);
        }
        
        public void openSignupPanel()
        {
            loginPanel.SetActive(false);
            signupPanel.SetActive(true);
            profilePanel.SetActive(false);
            forgetPasswordPanel.SetActive(false);
        }
        
        public void openProfilePanel()
        {
            loginPanel.SetActive(false);
            signupPanel.SetActive(false);
            profilePanel.SetActive(true);
            forgetPasswordPanel.SetActive(false);
        }
        
        public void forgotPasswordPanel()
        {
            loginPanel.SetActive(false);
            signupPanel.SetActive(false);
            profilePanel.SetActive(false);
            forgetPasswordPanel.SetActive(true);
        }
        
        private void messagePanel(string title, string message)
        {
            messageTitle.text =""+ title;
            this.message.text =""+ message;
            
            errorMessagePanel.SetActive(true);
        }

        public void closemessagePanel()
        {
            messageTitle.text ="";
            this.message.text ="";
            
            errorMessagePanel.SetActive(false);
        }
        

        public void loginUser()
        {
            if (string.IsNullOrEmpty(loginEmail.text) && string.IsNullOrEmpty(loginPassword.text))
            {
                messagePanel("Error","Fields Empty");
                return;
            }
            SignIn(loginEmail.text,loginPassword.text);
        }
        public void signupUser()
        {
            if (string.IsNullOrEmpty(signupEmail.text) && string.IsNullOrEmpty(signupPassword.text) && string.IsNullOrEmpty(signupCPassword.text) && string.IsNullOrEmpty(signupUsername.text))
            {
                messagePanel("Error","Fields Empty");
                return;
            }
            createNewUser(signupEmail.text,signupPassword.text,signupUsername.text);
        }
        public void forotPassword()
        {
            if (string.IsNullOrEmpty(forgetPasswordEmail.text))
            {
                messagePanel("Error","Forget Email Empty");
                return;
            }
        }

        public void logout()
        {
            auth.SignOut();
            useremail.text = "";
            username.text="";
            openLoginPanel();
        }

        public void createNewUser(string email, string password, string username)
        {
            auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {
                if (task.IsCanceled) {
                    Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                    return;
                }
                if (task.IsFaulted) {
                    Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                    return;
                }

                // Firebase user has been created.
                Firebase.Auth.FirebaseUser newUser = task.Result;
                Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                    newUser.DisplayName, newUser.UserId);
                //updateUserProfile(username);
            });
        }

        public void SignIn(string email, string password)
        {
            auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {
                if (task.IsCanceled) {
                    Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                    return;
                }
                if (task.IsFaulted) {
                    Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                    return;
                }

                Firebase.Auth.FirebaseUser newUser = task.Result;
                Debug.LogFormat("User signed in successfully: {0} ({1})",
                    newUser.DisplayName, newUser.UserId);
                this.username.text = "" + newUser.DisplayName;
                this.useremail.text = "" + newUser.Email;
                openProfilePanel();
            });
            
        }
        void InitializeFirebase() {
            auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
            auth.StateChanged += AuthStateChanged;
            AuthStateChanged(this, null);
        }

        void AuthStateChanged(object sender, System.EventArgs eventArgs) {
            if (auth.CurrentUser != user) {
                bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
                if (!signedIn && user != null) {
                    Debug.Log("Signed out " + user.UserId);
                }
                user = auth.CurrentUser;
                if (signedIn) {
                    Debug.Log("Signed in " + user.UserId);
                    isSignin = true;
                }
            }
        }
        void OnDestroy() {
            auth.StateChanged -= AuthStateChanged;
            auth = null;
        }

        void updateUserProfile(string username)
        {
            Firebase.Auth.FirebaseUser user = auth.CurrentUser;
            if (user != null) {
                Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile {
                    DisplayName = username,
                };
                user.UpdateUserProfileAsync(profile).ContinueWithOnMainThread(task => {
                    if (task.IsCanceled) {
                        Debug.LogError("UpdateUserProfileAsync was canceled.");
                        return;
                    }
                    if (task.IsFaulted) {
                        Debug.LogError("UpdateUserProfileAsync encountered an error: " + task.Exception);
                        return;
                    }

                    Debug.Log("User profile updated successfully.");
                    messagePanel("Alert","Account Successfully Created");
                });
            }
        }
        
        private bool isSigned = false;
        private void Update()
        {
            if (isSignin)
            {
                if (!isSigned)
                {
                    isSigned = true;
                    username.text = "" + user.DisplayName;
                    useremail.text = "" + user.Email;
                    openProfilePanel();
                }
            }
        }
    }
}