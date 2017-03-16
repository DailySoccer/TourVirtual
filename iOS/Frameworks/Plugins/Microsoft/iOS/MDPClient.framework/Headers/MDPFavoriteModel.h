//
//  MDPFavoriteModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPFavoriteModel.h"


#pragma mark - FavoriteType
typedef NS_ENUM(NSInteger, MDPFavoriteModelFavoriteType) {
    MDPFavoriteModelFavoriteTypeSubscription       = 0,
    MDPFavoriteModelFavoriteTypeContent            = 1,
    MDPFavoriteModelFavoriteTypeMatch              = 2,
};


#pragma mark - Interface
@interface MDPFavoriteModel : _MDPFavoriteModel

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
