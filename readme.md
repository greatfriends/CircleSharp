# CircleSharp
A .net wrapper for Circle.so API (v1)

# How to use 
```cs
using CircleSharp;

...
var c = new CircleNet("https://app.circle.so", your_api_token);

var me = c.GetMe();
Console.WriteLine(me.FirstName);
```

# CircleNet Methods
## Me
- GetMe()

## Communities 
- GetCommunities()
- GetCommunity(id)

## Space Groups
- GetSpaceGroups([communityId])
- GetSpaceGroup(spaceGroupId, [communityId])

## Spaces
- GetSpaces(spaceGroupId, [communityId], [sort="oldest"])
- GetSpace(spaceId, communityId)
- CreateSpace(spaceGroupId, communityId, name, slug, - ate, isHidden, isHiddenFromNonMember, isPostDisabled)
- DeleteSpace(spaceId, [forceDeleteNonEmptySpace=false])

## Members
- InviteMember(communityId, email, [name=null], - Id=null])
- GetUsers(communityId, [sort="latest"])
- GetUser(userId, [communityId])
