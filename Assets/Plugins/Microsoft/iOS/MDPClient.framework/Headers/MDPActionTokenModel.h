//
//  MDPActionTokenModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPActionTokenModel.h"


typedef NS_ENUM(NSInteger, MDPActionTokenModelTokenType) {
    MDPActionTokenModelTokenTypeUser                    = 0,
    MDPActionTokenModelTokenTypeVirtualGood             = 1,
    MDPActionTokenModelTokenTypeAchievement             = 2,
    MDPActionTokenModelTokenTypeCheckIn                 = 3,
    MDPActionTokenModelTokenTypeStoreProduct            = 4,
    MDPActionTokenModelTokenTypeSubscription            = 5,
    MDPActionTokenModelTokenTypePlayer                  = 6,
    MDPActionTokenModelTokenTypeFavorite                = 7,
    MDPActionTokenModelTokenTypeGroup                   = 8,
    MDPActionTokenModelTokenTypeFixed                   = 9,
    MDPActionTokenModelTokenTypeExternalIdentity        = 10,
    MDPActionTokenModelTokenTypeOffer                   = 11,
    MDPActionTokenModelTokenTypeCountry                 = 12,
    MDPActionTokenModelTokenTypeAction                  = 13,
    MDPActionTokenModelTokenTypeContent                 = 14,
    MDPActionTokenModelTokenTypeLink                    = 15,
    MDPActionTokenModelTokenTypeNetwork                 = 16,
};


#pragma mark - Interface
@interface MDPActionTokenModel : _MDPActionTokenModel

+ (instancetype)insertIfNotExistsActionTokenWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
