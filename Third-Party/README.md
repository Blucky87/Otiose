
## Third-Party Libraries

#### These libraries are git subtrees of the superproject (otiose).
All third-party libraries used are my personal forked versions.
<br />
<br />
### Example:
[My forked Nez](https://github.com/Blucky87/Nez) was added to the superproject as a subtree by calling the following at the root of :
<br />

```
git subtree add -P Third-Party/Nez git@github.com:Blucky87/Nez.git master --squash -m "added forked nez subtree"
```
<br />  
And to Use the following command to pull in a new commit of nez from the forked master branch if you ever need to update:
<br />    
<br />    

```
git subtree pull -P Third-Party/Nez git@github.com:Blucky87/Nez.git master --squash  
```

<br />

See your `man git subtree` or `git subtree -h` for more info on git subtrees.