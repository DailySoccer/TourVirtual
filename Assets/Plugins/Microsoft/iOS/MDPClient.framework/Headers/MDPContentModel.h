//
//  MDPContentModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPContentModel.h"

#pragma mark Content Types
typedef NS_ENUM(NSUInteger, MDPContentModelContentType) {
    MDPContentModelContentTypeUseAlternativeIfAny = -1,
    MDPContentModelContentTypeNews           = 0,
    MDPContentModelContentTypeVideos         = 1,
    MDPContentModelContentTypeFootBallNews   = 2,
    MDPContentModelContentTypeBasketNews     = 3,
    MDPContentModelContentTypeFootBallVideos = 4,
    MDPContentModelContentTypeBasketVideos   = 5,
    MDPContentModelContentTypeGamesWindows   = 6,
    MDPContentModelContentTypeGamesWP        = 7,
    MDPContentModelContentTypeGamesIOS       = 8,
    MDPContentModelContentTypeGamesAndroid   = 9,
    MDPContentModelContentTypeResource       = 10,
    MDPContentModelContentTypeLaDecima       = 11,
};


#pragma mark - Interface
@interface MDPContentModel : _MDPContentModel

+ (instancetype)contentWithId:(NSString *)idContent managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsContentWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (NSString *)typeNameForContentType:(MDPContentModelContentType)contentType;

@end
