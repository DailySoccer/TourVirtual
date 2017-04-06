//
//  _MDPTweetModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPTweetModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPTweetModelAttributes {
	__unsafe_unretained NSString *createdAt;
	__unsafe_unretained NSString *favoriteCount;
	__unsafe_unretained NSString *idTweet;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *text;
} MDPTweetModelAttributes;

extern const struct MDPTweetModelRelationships {
	__unsafe_unretained NSString *entities;
	__unsafe_unretained NSString *pagedTweetResults;
	__unsafe_unretained NSString *user;
} MDPTweetModelRelationships;

@class MDPTweetEntitiesModel;
@class MDPPagedTweetModel;
@class MDPTweetUserModel;

@interface _MDPTweetModel : NSManagedObject

@property (nonatomic, strong) NSDate* createdAt;

//- (BOOL)validateCreatedAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* favoriteCount;

@property (atomic) int64_t favoriteCountValue;
- (int64_t)favoriteCountValue;
- (void)setFavoriteCountValue:(int64_t)value_;

//- (BOOL)validateFavoriteCount:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* idTweet;

@property (atomic) int64_t idTweetValue;
- (int64_t)idTweetValue;
- (void)setIdTweetValue:(int64_t)value_;

//- (BOOL)validateIdTweet:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* text;

//- (BOOL)validateText:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPTweetEntitiesModel *entities;

//- (BOOL)validateEntities:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPagedTweetModel *pagedTweetResults;

//- (BOOL)validatePagedTweetResults:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPTweetUserModel *user;

//- (BOOL)validateUser:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPTweetModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveCreatedAt;
- (void)setPrimitiveCreatedAt:(NSDate*)value;

- (NSNumber*)primitiveFavoriteCount;
- (void)setPrimitiveFavoriteCount:(NSNumber*)value;

- (int64_t)primitiveFavoriteCountValue;
- (void)setPrimitiveFavoriteCountValue:(int64_t)value_;

- (NSNumber*)primitiveIdTweet;
- (void)setPrimitiveIdTweet:(NSNumber*)value;

- (int64_t)primitiveIdTweetValue;
- (void)setPrimitiveIdTweetValue:(int64_t)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveText;
- (void)setPrimitiveText:(NSString*)value;

- (MDPTweetEntitiesModel*)primitiveEntities;
- (void)setPrimitiveEntities:(MDPTweetEntitiesModel*)value;

- (MDPPagedTweetModel*)primitivePagedTweetResults;
- (void)setPrimitivePagedTweetResults:(MDPPagedTweetModel*)value;

- (MDPTweetUserModel*)primitiveUser;
- (void)setPrimitiveUser:(MDPTweetUserModel*)value;

@end
