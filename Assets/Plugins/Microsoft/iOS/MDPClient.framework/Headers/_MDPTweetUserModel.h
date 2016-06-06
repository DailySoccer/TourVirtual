//
//  _MDPTweetUserModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPTweetUserModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPTweetUserModelAttributes {
	__unsafe_unretained NSString *descriptionTweetUser;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *name;
	__unsafe_unretained NSString *profileImageUrl;
	__unsafe_unretained NSString *screenName;
} MDPTweetUserModelAttributes;

extern const struct MDPTweetUserModelRelationships {
	__unsafe_unretained NSString *tweetUser;
} MDPTweetUserModelRelationships;

@class MDPTweetModel;

@interface _MDPTweetUserModel : NSManagedObject

@property (nonatomic, strong) NSString* descriptionTweetUser;

//- (BOOL)validateDescriptionTweetUser:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* profileImageUrl;

//- (BOOL)validateProfileImageUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* screenName;

//- (BOOL)validateScreenName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPTweetModel *tweetUser;

//- (BOOL)validateTweetUser:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPTweetUserModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveDescriptionTweetUser;
- (void)setPrimitiveDescriptionTweetUser:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (NSString*)primitiveProfileImageUrl;
- (void)setPrimitiveProfileImageUrl:(NSString*)value;

- (NSString*)primitiveScreenName;
- (void)setPrimitiveScreenName:(NSString*)value;

- (MDPTweetModel*)primitiveTweetUser;
- (void)setPrimitiveTweetUser:(MDPTweetModel*)value;

@end
