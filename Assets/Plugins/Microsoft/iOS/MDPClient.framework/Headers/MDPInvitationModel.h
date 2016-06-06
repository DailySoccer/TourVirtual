//
//  MDPInvitationModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPInvitationModel.h"


#pragma mark InvitationRequestType
typedef NS_ENUM(NSInteger, MDPInvitationModelInvitationRequestType) {
    MDPInvitationModelInvitationRequestTypeGroup            = 0,
    MDPInvitationModelInvitationRequestTypeFriendship       = 1
} ;


#pragma mark - Interface
@interface MDPInvitationModel : _MDPInvitationModel

+ (NSArray *)invitationsWithManagedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsCompetitionWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
