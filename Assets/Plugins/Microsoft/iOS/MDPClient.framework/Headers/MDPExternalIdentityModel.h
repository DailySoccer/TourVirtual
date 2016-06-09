//
//  MDPExternalIdentityModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPExternalIdentityModel.h"


#pragma mark  - AdNavigationType
typedef NS_ENUM(NSInteger, MDPExternalIdentityModelIdentityProviderType) {
    MDPExternalIdentityModelIdentityProviderTypeFacebook     = 0,
    MDPExternalIdentityModelIdentityProviderTypeTwitter      = 1,
    MDPExternalIdentityModelIdentityProviderTypeGoogle       = 2,
    MDPExternalIdentityModelIdentityProviderTypeMicrosoft    = 3,
    MDPExternalIdentityModelIdentityProviderTypeLinkedIn     = 4,
    MDPExternalIdentityModelIdentityProviderTypeAmazon       = 5,
};


#pragma mark - Interface
@interface MDPExternalIdentityModel : _MDPExternalIdentityModel

+ (NSArray *)externalIdentitiesWithManagedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsExternalIdentityWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
